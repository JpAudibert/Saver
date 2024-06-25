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
      <BackHeader text="Log In" />

      <KeyboardAvoidingView
        behavior={Platform.OS === 'ios' ? 'position' : 'height'}
        style={{ width: '100%', left: '-25%' }}
      >
        <LoginContainer container="md">
          <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
            <LoginActionsContainer>
              <InputText label="Email" />
              <InputText label="Password" />
              <Button title="Log In" onPress={() => console.log('login')} />
            </LoginActionsContainer>
          </TouchableWithoutFeedback>
        </LoginContainer>
      </KeyboardAvoidingView>
    </PageContainer>
  );
}
