import styled, { css } from 'styled-components/native';

interface ContainerProps {
  isFocused: boolean;
  isErrored: boolean;
}

const Container = styled.View<ContainerProps>`
  width: 280px;
  height: 30px;
  padding: 0 16px;
  background: #d3b88c;
  border-radius: 10px;
  margin-bottom: 8px;
  border-width: 2px;
  border-color: #846c5b;

  flex-direction: row;
  align-items: center;

  ${(props) =>
    props.isErrored &&
    css`
      border-color: #c53030;
    `}

  ${(props) =>
    props.isFocused &&
    css`
      border-color: #c8ab83;
    `}
`;

const TextInput = styled.TextInput`
  flex: 1;
  color: #232129;
  font-size: 16px;
  /* font-family: 'RobotoSlab-Regular'; */
`;

export { Container, TextInput };
