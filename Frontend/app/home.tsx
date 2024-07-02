import Button from '@/components/Button';
import api from '@/services/api';
import { router } from 'expo-router';
import { useEffect } from 'react';
import { View, Text } from 'react-native';
import { TouchableOpacity } from 'react-native-gesture-handler';

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
      <Button title="Person" onPress={() => router.navigate('person')} />
    </View>
  );
};

export default Home;
