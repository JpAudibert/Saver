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
import { useRouter } from 'expo-router';
import { View, StyleSheet } from 'react-native';
import { Colors } from 'react-native/Libraries/NewAppScreen';

export default function Index() {
  const router = useRouter();
  return (
    <PageContainer>
      <Ball/>
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

