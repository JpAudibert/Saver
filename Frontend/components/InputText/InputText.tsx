import { Text, TextInput } from 'react-native';
import {
  TextInputContainer,
  TextContainer,
  InputTextContainer,
} from './styles';

interface InputTextProps {
  label?: string;
  value?: string;
  placeholder?: string;
  type?: string;
}

const InputText: React.FC<InputTextProps> = ({ label }) => {
  return (
    <InputTextContainer>
      <TextContainer>{label}</TextContainer>
      <TextInputContainer>
        <TextInput />
      </TextInputContainer>
    </InputTextContainer>
  );
};

export default InputText;
