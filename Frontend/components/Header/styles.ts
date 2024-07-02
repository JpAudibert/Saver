import styled from 'styled-components/native';
import { Colors } from '@/constants/Colors';

export const BackHeaderContainer = styled.View`
  display: flex;
  width: 100%;
  padding: 0 20px;
  margin-top: 20px;
`;

export const BackButton = styled.Pressable`
  display: flex;
  flex-direction: row;
  align-items: center;
  color: ${Colors.default.text};
`;

export const BakcContainer = styled.View`
  width: 300px;
  height: 300px;
  border-radius: 150px;
  background-color: ${Colors.default.gray};
  position: absolute;
  top: -180px;
  left: -120px;
`;
