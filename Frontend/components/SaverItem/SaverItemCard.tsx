import React, { useCallback, useState } from 'react';
import { Shadow } from 'react-native-shadow-2';
import { View, Text, Pressable } from 'react-native';
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
import api from '@/services/api';

interface SaverItemCardProps {
  id: string;
  title: string;
  value: number;
  type: 'income' | 'expense';
  afterDelete: () => void;
}

const SaverItemCard: React.FC<SaverItemCardProps> = ({
  id,
  type,
  title,
  value,
  afterDelete,
}) => {
  const [deleteVisible, setDeleteVisible] = useState(false);
  const [isDeleting, setIsDeleting] = useState(false);

  const handleDelete = useCallback(async () => {
    setIsDeleting(true);
    await api.delete(`finances/${id}`);
    afterDelete();
    setDeleteVisible(false);
    setIsDeleting(false);
  }, [afterDelete, id]);

  return (
    <Container
      onPress={() => {
        if (isDeleting) return;
        setDeleteVisible(v => !v);
      }}
    >
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

            {deleteVisible && (
              <Pressable onPress={() => handleDelete()}>
                <Ionicons name="trash" color={Colors.default.spending} />
              </Pressable>
            )}
          </TextContainer>
        </RowContainer>
      </Shadow>
    </Container>
  );
};

export default SaverItemCard;
