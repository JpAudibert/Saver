import React from 'react';
import { Shadow } from 'react-native-shadow-2';
import { View, Text } from 'react-native';
import { Ionicons } from '@expo/vector-icons';
import {
  Container,
  IconContainer,
  RowBadge,
  RowContainer,
  TextContainer,
} from './styles';
import { Colors } from '@/constants/Colors';
import { handleNumberToCurrency } from '@/utils/formatNumber';

interface SaverItemCardProps {
  title: string;
  value: number;
  type: 'income' | 'expense';
}

const SaverItemCard: React.FC<SaverItemCardProps> = ({
  type,
  title,
  value,
}) => {
  return (
    <Container>
      <Shadow
        distance={5}
        startColor="#00000010"
        style={{
          width: '100%',
          borderRadius: 4,
        }}
      >
        <RowContainer>
          <RowBadge type={type} />
          <TextContainer>
            <IconContainer>
              <Text style={{ paddingRight: 6 }}>
                {type === 'income' ? (
                  <Ionicons name="arrow-up" color={Colors.default.main} />
                ) : (
                  <Ionicons name="arrow-down" color={Colors.default.spending} />
                )}
              </Text>
              <Text>{title}</Text>
            </IconContainer>
            <Text>R$ {handleNumberToCurrency(value)}</Text>
          </TextContainer>
        </RowContainer>
      </Shadow>
    </Container>
  );
};

export default SaverItemCard;
