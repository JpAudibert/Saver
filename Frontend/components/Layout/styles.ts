import { Colors } from '@/constants/Colors';
import styled from 'styled-components/native';

export const LoginLayout = styled.View`
  height: 50%;
  width: 120%;
  border-radius: 500px 500px 0 0;
  position: 'absolute';
  top: 50%;
  right: 10%;
  background-color: ${Colors.default.main};
`;

export const HeaderText = styled.Text`
  color: ${Colors.default.main};
  font-size: 48px;
  font-weight: bold;
  letter-spacing: 0.5;
`;

export const SloganText = styled.Text`
  color: ${Colors.default.text};
  font-size: 16px;
  margin-top: 10px;
  font-weight: bold;
`;

export const HeaderContainer = styled.View`
  align-items: center;
  justify-content: center;

  top: 20%;
`;
