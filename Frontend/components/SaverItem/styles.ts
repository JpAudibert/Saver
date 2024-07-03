import { styled } from 'styled-components/native';
import { Colors } from '@/constants/Colors';

export const Container = styled.Pressable`
  margin: 10px;
`;

export const TextContainer = styled.View`
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 0px 20px;
`;

interface RowBadgeProps {
  type: 'income' | 'expense';
}

export const RowBadge = styled.View<RowBadgeProps>`
  width: 8px;
  background-color: ${props =>
    props.type === 'income' ? Colors.default.main : Colors.default.spending};
  height: 45px;
  border-radius: 1px;
`;

export const RowContainer = styled.View`
  display: flex;
  overflow: hidden;
  flex-direction: row;
  border-radius: 4px;
`;

export const IconContainer = styled.View`
  display: flex;
  flex-direction: row;
  align-items: center;
`;
