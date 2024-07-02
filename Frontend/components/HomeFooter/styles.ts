import styled from 'styled-components/native';
import { Colors } from '@/constants/Colors';

export const FooterContainer = styled.View`
  position: absolute;
  bottom: 0;
  width: 100%;
  flex-direction: row;
  justify-content: space-around;
  align-items: center;
  background-color: ${Colors.default.main};
  padding: 40px 30px;
`;
