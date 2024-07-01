import { Colors } from '@/constants/Colors';
import styled from 'styled-components/native';

export const ButtonContainer = styled.Pressable<{ fill: boolean }>`
  width: 150px;
  height: 45px;

  justify-content: center;
  align-items: center;

  background-color: ${(props) =>
    props.fill ? Colors.default.secondary : Colors.default.main};

  border-color: ${Colors.default.secondary};
  border-width: 2px;
  border-radius: 23px;

  margin: 20px;
`;
export const ButtonText = styled.Text<{ fill: boolean }>`
  font-weight: bold;
  font-size: 16px;
  color: ${(props) =>
    props.fill ? Colors.default.text : Colors.default.secondary};
  line-height: 21px;
`;
