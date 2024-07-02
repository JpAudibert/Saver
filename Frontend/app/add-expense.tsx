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
  Text,
} from 'react-native';
import * as Yup from 'yup';
import Button from '@/components/Button';
import BackHeader from '@/components/Header/BackHeader';
import InputText from '@/components/InputText/InputText';
import { LoginContainer, PageContainer } from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import api from '@/services/api';

interface FinanceData {
  amount: number;
  description: string;
}

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

export default function AddFinance() {
  const formRef = useRef<FormHandles>(null);
  const descriptionInputRef = useRef<TextInput>(null);

  const handleUpdate = useCallback(
    async ({ amount, description }: FinanceData): Promise<void> => {
      try {
        formRef.current?.setErrors({});
        const schema = Yup.object().shape({
          amount: Yup.number().required('Amount is required'),
          description: Yup.string().required('Description is required'),
        });

        const formData = {
          amount,
          description,
          type: 'expense',
        };

        await api.post('/finances', formData);

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
    [],
  );

  return (
    <PageContainer>
      <BackHeader text="Home" />
      <Text
        style={{
          fontSize: 24,
          fontWeight: 'bold',
          textAlign: 'center',
          marginTop: 20,
        }}
      >
        Add a new expense
      </Text>
      <KeyboardAvoidingView
        behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
        style={{ width: '100%', left: '-25%' }}
      >
        <LoginContainer container="md">
          <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
            <Form
              ref={formRef}
              initialData={{
                amount: 0,
                description: '',
              }}
              onSubmit={handleUpdate}
            >
              <LoginActionsContainer>
                <InputText
                  name="amount"
                  placeholder="Amount"
                  keyboardType="numeric"
                  returnKeyType="next"
                  onSubmitEditing={() => descriptionInputRef.current?.focus()}
                />
                <InputText
                  name="description"
                  placeholder="Description"
                  returnKeyType="send"
                  onSubmitEditing={() => formRef.current?.submitForm()}
                />
                <Button
                  title="Add"
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
