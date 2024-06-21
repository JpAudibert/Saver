import Button from '@/components/Button';
import {
  HeaderContainer,
  HeaderText,
  LoginLayout,
  SloganText,
} from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import { View } from 'react-native';

export default function Index() {
  return (
    <View style={{ flex: 1 }}>
      <HeaderContainer>
        <HeaderText>SAVER</HeaderText>
        <SloganText>Saving your money is our goal</SloganText>
      </HeaderContainer>

      <LoginLayout>
        <LoginActionsContainer>
          <Button title="Log In" onPress={() => console.log('login')} />
          <Button
            title="Sign Up"
            onPress={() => console.log('sign up')}
            fill={false}
          />
        </LoginActionsContainer>
      </LoginLayout>
    </View>
  );
}
