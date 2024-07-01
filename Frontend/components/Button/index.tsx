import { ButtonProps } from 'react-native';
import { ButtonContainer, ButtonText } from './styles';

interface CustomButtonProps {
  title: string;
  onPress: () => void;
  fill?: boolean;
}
type ButtonType = CustomButtonProps & ButtonProps;

const Button: React.FC<ButtonType> = ({
  title,
  onPress,
  fill = true,
  ...rest
}) => {
  return (
    <ButtonContainer fill={fill} onPress={onPress} {...rest}>
      <ButtonText fill={fill}>{title}</ButtonText>
    </ButtonContainer>
  );
};

export default Button;
