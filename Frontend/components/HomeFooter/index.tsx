import { Colors } from '@/constants/Colors';
import { Ionicons } from '@expo/vector-icons';
import { View, Text } from 'react-native';
import { FooterContainer } from './styles';

const HomeFooter: React.FC = () => {
  return (
    <FooterContainer>
      <View>
        <Text
          style={{
            fontSize: 20,
            fontWeight: 700,
            color: Colors.default.background,
          }}
        >
          Home
        </Text>
      </View>
      <View>
        <Text
          style={{
            fontSize: 20,
            fontWeight: 700,
            color: Colors.default.background,
          }}
        >
          <Ionicons name="home" size={24} color={Colors.default.background} />
        </Text>
      </View>
    </FooterContainer>
  );
};

export default HomeFooter;
