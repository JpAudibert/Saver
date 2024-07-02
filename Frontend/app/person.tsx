import BackHeader from "@/components/Header/BackHeader";
import InputText from "@/components/InputText/InputText";
import { LoginContainer, PageContainer } from "@/components/Layout/styles";
import { LoginActionsContainer } from "@/components/LoginActions/styles";
import api from "@/services/api";
import { FormHandles } from "@unform/core";
import { Form } from "@unform/mobile";
import { router } from "expo-router";
import { useCallback, useRef } from "react";
import { Alert, Button, Keyboard, KeyboardAvoidingView, Platform, TextInput, TouchableWithoutFeedback } from "react-native";

import * as Yup from 'yup';

interface SignUpFormData {
    email: string;
    password: string;
    confirmPassword: string;
    cpf: string;
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

    function getValidationErrors(err: Yup.ValidationError): Errors {
        const validationError: Errors = {};

        err.inner.forEach((error) => {
            validationError[error.path || ''] = error.message;
        });

        return validationError;
    }

    const handleUpdate = useCallback(async ({ email, password, confirmPassword, cpf, name, isActive }: SignUpFormData): Promise<void> => {
        try {
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
                    'Passwords must be equal'
                ),
            });

            await schema.validate(
                { email, password, confirmPassword, cpf, name },
                {
                    abortEarly: false,
                }
            );

            const formData = {
                name,
                email,
                password,
                identificationNumber: cpf,
                isActive: true
            }

            await api.put(`/users/${api.defaults.headers.userId}`, formData);

            router.navigate('home');
        } catch (err) {
            console.log(err);
            if (err instanceof Yup.ValidationError) {
                const errors = getValidationErrors(err);

                formRef.current?.setErrors(errors);

                

                return;
            }

            Alert.alert(
                'Error on updating person',
                'Please check the informed data and try again.'
            );
        }
    }, [])

    return (
        <PageContainer>
            <BackHeader text="Sign Up" />

            <KeyboardAvoidingView
                behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
                style={{ width: '100%', left: '-25%' }}
            >
                <LoginContainer container="lg">
                    <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
                        <Form ref={formRef} onSubmit={handleUpdate}>
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
                                    mask="cpf"
                                    returnKeyType="next"
                                    keyboardType="numeric"
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