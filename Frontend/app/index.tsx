import Button from '@/components/Button';
import {
  HeaderContainer,
  HeaderText,
  LoginContainer,
  PageContainer,
  SloganText,
} from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import { useRouter } from 'expo-router';

export default function Index() {
  const router = useRouter();
  return (
    <PageContainer>
      <HeaderContainer>
        <HeaderText>SAVER</HeaderText>
        <SloganText>Saving your money is our goal</SloganText>
      </HeaderContainer>

      <LoginContainer container="sm">
        <LoginActionsContainer>
          <Button title="Log In" onPress={() => router.navigate('login')} />
          <Button
            title="Sign Up"
            onPress={() => router.navigate('signup')}
            fill={false}
          />
        </LoginActionsContainer>
      </LoginContainer>
    </PageContainer>
  );
}
