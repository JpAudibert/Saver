import { useRouter } from 'expo-router';
import { Pressable } from 'react-native';
import Button from '@/components/Button';
import Ball from '@/components/Header/Ball';
import {
  HeaderContainer,
  HeaderText,
  LoginContainer,
  PageContainer,
  SloganText,
} from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import { useAuth } from '@/hooks/auth';
import { Colors } from '@/constants/Colors';

export default function Index() {
  const router = useRouter();
  const { signIn } = useAuth();
  return (
    <PageContainer>
      <Ball />
      <HeaderContainer>
        <Pressable
          onPress={() => {
            signIn({
              email: 'renatafan@email.com',
              password: 'renatafanJogoAberto',
            });
            router.navigate('home');
          }}
        >
          <HeaderText>SAVER</HeaderText>
        </Pressable>
        <SloganText>Saving your money is our goal</SloganText>
      </HeaderContainer>

      <LoginContainer container="sm" color={Colors.default.main}>
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
