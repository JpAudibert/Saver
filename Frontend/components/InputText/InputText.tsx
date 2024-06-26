import React, {
  useEffect,
  useRef,
  useImperativeHandle,
  forwardRef,
  useState,
  useCallback,
} from 'react';
import { TextInputProps } from 'react-native';

import { Container, TextInput } from './styles';
import { useField } from '@unform/core';

interface InputProps extends TextInputProps {
  name: string;
  mask?: 'cpf';
}

interface InputValueReference {
  value: string;
}
interface InputRef {
  focus(): void;
}

const Input: React.ForwardRefRenderFunction<InputRef, InputProps> = (
  { name, mask = null, ...rest },
  ref
) => {
  const inputElementRef = useRef<any>(null);
  const {
    registerField,
    defaultValue = '',
    fieldName,
    error,
  } = useField(name ?? '');
  const inputValueRef = useRef<InputValueReference>({ value: defaultValue });

  const [isFocused, setIsFocused] = useState(false);
  const [isFilled, setIsFilled] = useState(false);

  const handleInputFocus = useCallback(() => {
    setIsFocused(true);
  }, []);

  const handleInputBlur = useCallback(() => {
    setIsFocused(false);

    setIsFilled(!!inputValueRef.current.value);
  }, []);

  useImperativeHandle(ref, () => ({
    focus() {
      inputElementRef?.current?.focus();
    },
  }));

  useEffect(() => {
    registerField<string>({
      name: fieldName,
      ref: inputValueRef.current,
      path: 'value',
      setValue: (ref: any, value: string) => {
        inputValueRef.current.value = value;
        inputElementRef.current.setNativeProps({ text: value });
      },
      clearValue() {
        inputValueRef.current.value = '';
        inputElementRef.current.clear();
      },
    });
  }, [fieldName, registerField, inputValueRef.current.value]);

  return (
    <Container isFocused={isFocused} isErrored={!!error}>
      <TextInput
        keyboardAppearance="dark"
        placeholderTextColor="#232129"
        defaultValue={defaultValue}
        onFocus={handleInputFocus}
        onBlur={handleInputBlur}
        onChangeText={(value) => {
          inputValueRef.current.value = value;
          // inputElementRef.current.value = handleMask(value);
        }}
        {...rest}
      />
    </Container>
  );
};

export default forwardRef(Input);
