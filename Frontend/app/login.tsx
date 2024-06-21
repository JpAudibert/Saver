import Button from '@/components/Button';
import {
  HeaderContainer,
  HeaderText,
  LoginLayout,
  SloganText,
} from '@/components/Layout/styles';
import { LoginActionsContainer } from '@/components/LoginActions/styles';
import { useRouter } from 'expo-router';
import { Pressable, View } from 'react-native';

export default function Index() {
  const router = useRouter();
  return (
    <View style={{ flex: 1 }}>
      <HeaderContainer>
        <Pressable onPress={() => router.push('/')}>{'<- back'}</Pressable>
        <SloganText>Log In</SloganText>
      </HeaderContainer>

      <LoginLayout>
        <LoginActionsContainer>
          <Button title="Log In" onPress={() => console.log('login')} />
        </LoginActionsContainer>
      </LoginLayout>
    </View>
  );
}
