import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import { router } from 'expo-router';
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
import Button from '@/components/Button';
import BackHeader from '@/components/Header/BackHeader';
import InputText from '@/components/InputText/InputText';
import { LoginContainer, PageContainer } from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import { useAuth } from '@/hooks/auth';
import { Colors } from '@/constants/Colors';

interface Errors {
  [key: string]: string;
}

function getValidationErrors(err: Yup.ValidationError): Errors {
  const validationError: Errors = {};

  err.inner.forEach(error => {
    validationError[error.path || ''] = error.message;
  });

  return validationError;
}
interface SignInFormData {
  email: string;
  password: string;
}
export default function Index() {
  const formRef = useRef<FormHandles>(null);
  const passwordInputRef = useRef<TextInput>(null);

  const { signIn } = useAuth();

  const handleSignIn = useCallback(
    async ({ email, password }: SignInFormData): Promise<void> => {
      try {
        formRef.current?.setErrors({});
        const schema = Yup.object().shape({
          email: Yup.string()
            .required('E-mail obrigatório')
            .email('Digite um e-mail válido'),
          password: Yup.string().required('Senha obrigatória'),
        });

        await schema.validate(
          { email, password },
          {
            abortEarly: false,
          },
        );
        await signIn({
          email,
          password,
        });

        router.navigate('home');
      } catch (err) {
        if (err instanceof Yup.ValidationError) {
          const errors = getValidationErrors(err);

          formRef.current?.setErrors(errors);

          return;
        }

        Alert.alert(
          'Erro na autenticacao',
          'Ocorreu um erro ao fazer login, cheque as credenciais',
        );
      }
    },
    [signIn],
  );

  return (
    <PageContainer>
      <BackHeader text="Log In" />

      <KeyboardAvoidingView
        behavior={Platform.OS === 'ios' ? 'position' : 'height'}
        style={{ width: '100%', left: '-25%' }}
      >
        <LoginContainer container="md" color={Colors.default.main}>
          <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
            <Form ref={formRef} onSubmit={handleSignIn}>
              <LoginActionsContainer>
                <InputText
                  name="email"
                  placeholder="E-mail"
                  autoCorrect={false}
                  autoCapitalize="none"
                  keyboardType="email-address"
                  returnKeyType="next"
                  onSubmitEditing={() => passwordInputRef.current?.focus()}
                />
                <InputText
                  ref={passwordInputRef}
                  name="password"
                  placeholder="Senha"
                  secureTextEntry
                  returnKeyType="send"
                  // onSubmitEditing={() => formRef.current?.submitForm()}
                />
                <Button
                  title="Log In"
                  onPress={() => formRef.current?.submitForm()}
                />
              </LoginActionsContainer>
            </Form>
          </TouchableWithoutFeedback>
        </LoginContainer>
      </KeyboardAvoidingView>
    </PageContainer>
  );
}
