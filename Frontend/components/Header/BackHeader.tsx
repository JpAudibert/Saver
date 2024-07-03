import React from 'react';
import { useRouter } from 'expo-router';
import { Text } from 'react-native';
import { Ionicons } from '@expo/vector-icons';
import { SloganText } from '../Layout/styles';
import { BackButton, BackHeaderContainer, BakcContainer } from './styles';

interface BackHeaderProps {
  text: string;
}

const BackHeader: React.FC<BackHeaderProps> = ({ text }) => {
  const router = useRouter();
  return (
    <BackHeaderContainer>
      <BakcContainer />
      <BackButton onPress={() => router.back()}>
        <Ionicons name="arrow-back" size={24} color="#000" />
        <Text>Back</Text>
      </BackButton>
      <SloganText>{text}</SloganText>
    </BackHeaderContainer>
  );
};

export default BackHeader;
