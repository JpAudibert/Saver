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
  const [field, setField] = useState('');
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

  const handleMask = useCallback(
    (value: string) => {
      console.log(value);
      if (mask === 'cpf') {
        return value
          .replace(/\D/g, '') // substitui qualquer caracter que nao seja numero por nada
          .replace(/(\d{3})(\d)/, '$1.$2') // coloca ponto entre o terceiro e o quarto digito
          .replace(/(\d{3})(\d)/, '$1.$2') // coloca ponto entre o setimo e o oitavo digito
          .replace(/(\d{3})(\d{1,2})/, '$1-$2') // coloca um hifen entre o terceiro e o quarto digito
          .replace(/(-\d{2})\d+?$/, '$1'); // Impede que mais dígitos sejam inseridos
      }
      return value;
    },
    [mask]
  );

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
        const newValue = handleMask(value);
        setField(newValue);
        inputElementRef.current.setNativeProps({ text: newValue });
      },
      clearValue() {
        setField('');
        inputElementRef.current.clear();
      },
    });
  }, [fieldName, registerField]);

  return (
    <Container isFocused={isFocused} isErrored={!!error}>
      <TextInput
        keyboardAppearance="dark"
        placeholderTextColor="#232129"
        defaultValue={defaultValue}
        onFocus={handleInputFocus}
        onBlur={handleInputBlur}
        onChangeText={(value) => {
          setField(handleMask(value));
        }}
        value={field}
        {...rest}
      />
    </Container>
  );
};

export default forwardRef(Input);
