import Button from '@/components/Button';
import {
  HeaderContainer,
  HeaderText,
  LoginLayout,
  SloganText,
} from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import { useRouter } from 'expo-router';
import { View } from 'react-native';

export default function Index() {
  const router = useRouter();
  return (
    <View style={{ flex: 1 }}>
      <HeaderContainer>
        <HeaderText>SAVER</HeaderText>
        <SloganText>Saving your money is our goal</SloganText>
      </HeaderContainer>

      <LoginLayout>
        <LoginActionsContainer>
          <Button title="Log In" onPress={() => router.navigate('login')} />
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
