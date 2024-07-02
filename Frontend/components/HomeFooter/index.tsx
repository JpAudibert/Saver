import React from 'react';
import { Ionicons } from '@expo/vector-icons';
import { View, Text, Button } from 'react-native';
import { router } from 'expo-router';
import { Colors } from '@/constants/Colors';
import { FooterContainer } from './styles';

const HomeFooter: React.FC = () => {
  return (
    <FooterContainer>
      <View>
        <Text
          style={{
            fontSize: 20,
            fontWeight: 700,
            color: Colors.default.background,
          }}
        >
          Home
        </Text>
      </View>
      <View>
        <Text
          style={{
            fontSize: 20,
            fontWeight: 700,
            color: Colors.default.background,
          }}
        >
          <Ionicons name="home" size={24} color={Colors.default.background} />
        </Text>
      </View>
      <Button title="Person" onPress={() => router.navigate('person')} />
    </FooterContainer>
  );
};

export default HomeFooter;
