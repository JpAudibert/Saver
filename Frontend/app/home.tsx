import api from '@/services/api';
import { useEffect } from 'react';
import { View, Text } from 'react-native';

const Home: React.FC = () => {
  useEffect(() => {
    const teste = async () => {
      const { data } = await api.get('finances');
      console.log(data);
    };
    teste();
  }, []);
  return (
    <View>
      <Text>Home</Text>
    </View>
  );
};

export default Home;
