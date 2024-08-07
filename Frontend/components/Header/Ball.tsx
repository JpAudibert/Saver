import React from 'react';
import { SloganText } from '../Layout/styles';
import { useRouter } from 'expo-router';
import { Pressable, Text, View } from 'react-native';
import { Ionicons } from '@expo/vector-icons';
import { BackButton, BackHeaderContainer, BakcContainer, BallContainer } from './styles';


const Ball: React.FC = () => {
  const router = useRouter();
  return (
    <BackHeaderContainer>
      <BallContainer />
    </BackHeaderContainer>
  );
};

export default Ball;
