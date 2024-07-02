import styled, { css } from 'styled-components/native';

interface ContainerProps {
  isFocused: boolean;
  isErrored: boolean;
}

const Container = styled.View<ContainerProps>`
  width: 280px;
  height: 40px;
  padding: 0 16px;
  background: #F6FCF6;
  border-radius: 10px;
  margin-bottom: 16px;
  border-width: 2px;
  flex-direction: row;
  align-items: center;
  border-color: #235789;
`;

const TextInput = styled.TextInput`
  flex: 1;
  color: #235789;
  font-size: 16px;
  /* font-family: 'RobotoSlab-Regular'; */
`;

export { Container, TextInput };
