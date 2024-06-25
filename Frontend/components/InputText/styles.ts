import { Colors } from '@/constants/Colors';
import styled from 'styled-components/native';

export const InputTextContainer = styled.View`
  margin-top: 20px;
  align-items: left;
`;

export const TextInputContainer = styled.View`
  height: 30px;
  width: 300px;

  border-radius: 5px;

  padding: 7px 10px;
  text-justify: center;
  background-color: ${Colors.default.background};
`;

export const TextContainer = styled.Text`
  font-size: 16px;
  color: ${Colors.default.text};
  font-weight: bold;
`;
