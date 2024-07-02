import React from 'react';
import { ButtonProps } from 'react-native';
import { ButtonContainer, ButtonText } from './styles';

interface CustomButtonProps {
  title: string;
  onPress: () => void;
  fill?: boolean;
}
type ButtonType = CustomButtonProps & ButtonProps;

const Button: React.FC<ButtonType> = ({ title, onPress, fill, ...rest }) => {
  return (
    <ButtonContainer fill={fill} onPress={onPress} {...rest}>
      <ButtonText fill={fill}>{title}</ButtonText>
    </ButtonContainer>
  );
};

Button.defaultProps = {
  fill: true,
};

export default Button;
