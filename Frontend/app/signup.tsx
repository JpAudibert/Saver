import Button from '@/components/Button';
import BackHeader from '@/components/Header/BackHeader';
import InputText from '@/components/InputText/InputText';
import { LoginContainer, PageContainer } from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import { useAuth } from '@/hooks/auth';
import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import { useCallback, useRef } from 'react';
import {
  Alert,
  Keyboard,
  KeyboardAvoidingView,
  Platform,
  TextInput,
  TouchableWithoutFeedback,
} from 'react-native';

import * as Yup from 'yup';

interface SignUpFormData {
  email: string;
  password: string;
  confirmPassword: string;
  cpf: string;
  name: string;
}
interface Errors {
  [key: string]: string;
}

function getValidationErrors(err: Yup.ValidationError): Errors {
  const validationError: Errors = {};

  err.inner.forEach((error) => {
    validationError[error.path || ''] = error.message;
  });

  return validationError;
}

export default function Index() {
  const formRef = useRef<FormHandles>(null);
  const cpfInputRef = useRef<TextInput>(null);
  const emailInputRef = useRef<TextInput>(null);
  const passwordInputRef = useRef<TextInput>(null);
  const confirmPasswordInputRef = useRef<TextInput>(null);

  const { signUp } = useAuth();

  const handleSignUp = useCallback(
    async ({
      email,
      password,
      confirmPassword,
      cpf,
      name,
    }: SignUpFormData): Promise<void> => {
      try {
        formRef.current?.setErrors({});
        const schema = Yup.object().shape({
          name: Yup.string().required('Nome obrigatório'),
          cpf: Yup.string().required('CPF obrigatório'),
          email: Yup.string()
            .required('E-mail obrigatório')
            .email('Digite um e-mail válido'),
          password: Yup.string().required('Senha obrigatória'),
          confirmPassword: Yup.string().oneOf(
            [Yup.ref('password')],
            'As senhas precisam ser iguais'
          ),
        });

        await schema.validate(
          { email, password, confirmPassword, cpf, name },
          {
            abortEarly: false,
          }
        );
        await signUp({
          email,
          password,
          cpf,
          name,
        });
      } catch (err) {
        if (err instanceof Yup.ValidationError) {
          const errors = getValidationErrors(err);

          formRef.current?.setErrors(errors);

          return;
        }

        Alert.alert(
          'Erro na autenticacao',
          'Ocorreu um erro ao fazer login, cheque as credenciais'
        );
      }
    },
    []
  );
  return (
    <PageContainer>
      <BackHeader text="Sign Up" />

      <KeyboardAvoidingView
        behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
        style={{ width: '100%', left: '-25%' }}
      >
        <LoginContainer container="lg">
          <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
            <Form ref={formRef} onSubmit={handleSignUp}>
              <LoginActionsContainer>
                <InputText
                  name="name"
                  placeholder="Name"
                  autoCorrect={false}
                  returnKeyType="next"
                  onSubmitEditing={() => cpfInputRef.current?.focus()}
                />
                <InputText
                  name="cpf"
                  placeholder="CPF"
                  autoCorrect={false}
                  returnKeyType="next"
                  onSubmitEditing={() => emailInputRef.current?.focus()}
                  ref={cpfInputRef}
                />
                <InputText
                  name="email"
                  placeholder="E-mail"
                  autoCorrect={false}
                  autoCapitalize="none"
                  keyboardType="email-address"
                  returnKeyType="next"
                  onSubmitEditing={() => passwordInputRef.current?.focus()}
                  ref={emailInputRef}
                />
                <InputText
                  name="password"
                  placeholder="Password"
                  secureTextEntry
                  returnKeyType="next"
                  onSubmitEditing={() =>
                    confirmPasswordInputRef.current?.focus()
                  }
                  ref={passwordInputRef}
                />
                <InputText
                  name="confirmPassword"
                  placeholder="Confirm Password"
                  secureTextEntry
                  returnKeyType="send"
                  onSubmitEditing={() => formRef.current?.submitForm()}
                  ref={confirmPasswordInputRef}
                />
                <Button
                  title="Sign Up"
                  onPress={() => formRef?.current?.submitForm()}
                />
              </LoginActionsContainer>
            </Form>
          </TouchableWithoutFeedback>
        </LoginContainer>
      </KeyboardAvoidingView>
    </PageContainer>
  );
}
