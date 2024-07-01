import { Colors } from '@/constants/Colors';
import styled from 'styled-components/native';

interface LoginContainerProps {
  container: 'lg' | 'md' | 'sm';
}

export const PageContainer = styled.View`
  flex: 1;

  align-items: center;

  justify-content: space-between;
`;

export const LoginContainer = styled.View<LoginContainerProps>`
  min-height: ${(props) =>
    props.container === 'lg'
      ? '550px'
      : props.container === 'md'
      ? '410px'
      : '350px'};
  width: 150%;
  border-radius: 700px 700px 0 0;
  background-color: ${Colors.default.main};
`;

export const HeaderText = styled.Text`
  color: ${Colors.default.main};
  font-size: 48px;
  font-weight: bold;
  letter-spacing: 0.5px;

  margin-top: 80px;
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
`;
