import React from 'react';
import { Ionicons } from '@expo/vector-icons';
import { Pressable } from 'react-native';
import { router } from 'expo-router';
import { Colors } from '@/constants/Colors';
import { FooterContainer } from './styles';

const HomeFooter: React.FC = () => {
  return (
    <FooterContainer>
      <Pressable onPress={() => router.navigate('add-finance')}>
        <Ionicons name="cash" size={24} color={Colors.default.background} />
      </Pressable>
      <Pressable onPress={() => router.navigate('home')}>
        <Ionicons
          name="home-outline"
          size={24}
          color={Colors.default.background}
        />
      </Pressable>
      <Pressable onPress={() => router.navigate('add-expense')}>
        <Ionicons name="flame" size={24} color={Colors.default.background} />
      </Pressable>
    </FooterContainer>
  );
};

export default HomeFooter;
