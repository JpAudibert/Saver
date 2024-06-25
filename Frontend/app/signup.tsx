import Button from '@/components/Button';
import BackHeader from '@/components/Header/BackHeader';
import InputText from '@/components/InputText/InputText';
import { LoginContainer, PageContainer } from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import {
  Keyboard,
  KeyboardAvoidingView,
  Platform,
  TouchableWithoutFeedback,
} from 'react-native';

export default function Index() {
  return (
    <PageContainer>
      <BackHeader text="Sign Up" />

      <KeyboardAvoidingView
        behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
        style={{ width: '100%', left: '-25%' }}
      >
        <LoginContainer container="lg">
          <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
            <LoginActionsContainer>
              <InputText label="Name" />
              <InputText label="Email" />
              <InputText label="Password" />
              <InputText label="Confirm Password" />
              <Button title="Sign Up" onPress={() => console.log('signup')} />
            </LoginActionsContainer>
          </TouchableWithoutFeedback>
        </LoginContainer>
      </KeyboardAvoidingView>
    </PageContainer>
  );
}
