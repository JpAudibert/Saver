import { FormHandles } from '@unform/core';
import { Form } from '@unform/mobile';
import { router } from 'expo-router';
import { useCallback, useEffect, useRef, useState } from 'react';
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
import api from '@/services/api';

interface PersonData {
  email: string;
  password: string;
  confirmPassword: string;
  identificationNumber: string;
  name: string;
  isActive: boolean;
}

interface Errors {
  [key: string]: string;
}

export default function Person() {
  const formRef = useRef<FormHandles>(null);
  const cpfInputRef = useRef<TextInput>(null);
  const emailInputRef = useRef<TextInput>(null);
  const passwordInputRef = useRef<TextInput>(null);
  const confirmPasswordInputRef = useRef<TextInput>(null);

  const [person, setPerson] = useState({} as PersonData);

  function getValidationErrors(err: Yup.ValidationError): Errors {
    const validationError: Errors = {};

    err.inner.forEach(error => {
      validationError[error.path || ''] = error.message;
    });

    return validationError;
  }

  useEffect(() => {
    api
      .get(`/users/${api.defaults.headers.userId}`)
      .then(response => {
        setPerson(response.data);
      })
      .catch(err => {
        console.log(err);
      });
  }, []);

  const handleUpdate = useCallback(
    async ({
      name,
      email,
      identificationNumber,
      password,
      confirmPassword,
    }: PersonData): Promise<void> => {
      try {
        const newName = name === '' ? person.name : name;
        const newEmail = email === '' ? person.email : email;
        const newIdentificationNumber =
          identificationNumber === ''
            ? person.identificationNumber
            : identificationNumber;
        const newPassword = password === '' ? person.password : password;

        formRef.current?.setErrors({});
        const schema = Yup.object().shape({
          name: Yup.string().required('Name is required'),
          cpf: Yup.string().required('CPF is required'),
          email: Yup.string()
            .required('E-mail is required')
            .email('Type in a valid e-mail'),
          password: Yup.string().required('Pasaaword is required'),
          confirmPassword: Yup.string().oneOf(
            [Yup.ref('password')],
            'Passwords must be equal',
          ),
        });

        console.log('validating schema');

        // let result = await schema.validate(
        //     { email, password, confirmPassword, identificationNumber, name },
        //     {
        //         abortEarly: false,
        //     }
        // );

        // console.log(result);

        const formData = {
          newName,
          newEmail,
          newPassword,
          newIdentificationNumber,
          isActive: true,
        };

        console.log(formData);

        await api.put(`/users/${api.defaults.headers.userId}`, formData);

        router.navigate('home');
      } catch (err) {
        if (err instanceof Yup.ValidationError) {
          const errors = getValidationErrors(err);

          formRef.current?.setErrors(errors);

          return;
        }

        Alert.alert(
          'Error on updating person',
          'Please check the informed data and try again.',
        );
      }
    },
    [person],
  );

  return (
    <PageContainer>
      <BackHeader text="Home" />

      <KeyboardAvoidingView
        behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
        style={{ width: '100%', left: '-25%' }}
      >
        <LoginContainer container="lg">
          <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
            <Form
              ref={formRef}
              initialData={{
                name: person.name,
                identificationNumber: person.identificationNumber,
                email: person.email,
                password: person.password,
                confirmPassword: '',
              }}
              onSubmit={handleUpdate}
            >
              <LoginActionsContainer>
                <InputText
                  name="name"
                  placeholder="Name"
                  autoCorrect={false}
                  returnKeyType="next"
                  onSubmitEditing={() => cpfInputRef.current?.focus()}
                />
                <InputText
                  name="identificationNumber"
                  placeholder="identificationNumber"
                  autoCorrect={false}
                  mask="cpf"
                  returnKeyType="next"
                  keyboardType="numeric"
                  ref={cpfInputRef}
                  onSubmitEditing={() => emailInputRef.current?.focus()}
                />
                <InputText
                  name="email"
                  placeholder="E-mail"
                  autoCorrect={false}
                  autoCapitalize="none"
                  keyboardType="email-address"
                  returnKeyType="next"
                  ref={emailInputRef}
                  onSubmitEditing={() => passwordInputRef.current?.focus()}
                />
                <InputText
                  name="password"
                  placeholder="Password"
                  secureTextEntry
                  returnKeyType="next"
                  ref={passwordInputRef}
                  onSubmitEditing={() =>
                    confirmPasswordInputRef.current?.focus()
                  }
                />
                <InputText
                  name="confirmPassword"
                  placeholder="Confirm Password"
                  secureTextEntry
                  returnKeyType="send"
                  ref={confirmPasswordInputRef}
                  onSubmitEditing={() => formRef.current?.submitForm()}
                />
                <Button
                  title="Update"
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
