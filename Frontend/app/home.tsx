import { Ionicons } from '@expo/vector-icons';
import React, { useEffect, useMemo, useState } from 'react';
<<<<<<< HEAD
import { View, Text, Pressable, ScrollView } from 'react-native';
=======
import { View, Text, Pressable, SafeAreaView, ScrollView } from 'react-native';
>>>>>>> 738a9e6731506c64ccbd165eb0b65e4e2e22b6b8
import { router } from 'expo-router';
import HomeFooter from '@/components/HomeFooter';
import SaverItemCard from '@/components/SaverItem/SaverItemCard';
import { Colors } from '@/constants/Colors';
import api from '@/services/api';
import { handleNumberToCurrency } from '@/utils/formatNumber';
import { CustomViewArea } from '@/components/ViewArea/styles';

interface Finance {
  id: string;
  amount: number;
  description: string;
  type: 'income' | 'expense';
}

const Home: React.FC = () => {
  const [finances, setFinances] = useState<Finance[]>([]);

  const balance = useMemo(() => {
    return handleNumberToCurrency(
      finances.reduce((acc, finance) => {
        return finance.type === 'income'
          ? acc + finance.amount
          : acc - finance.amount;
      }, 0),
    );
  }, [finances]);

  useEffect(() => {
    const fetchData = async () => {
      const { data } = await api.get<Finance[]>('finances');
      setFinances(data);
    };
    fetchData();
  }, []);

  return (
    <View
      style={{
        backgroundColor: Colors.default.background,
        width: '100%',
        height: '100%',
      }}
    >
      <View>
        <View
          style={{
            flexDirection: 'row',
            justifyContent: 'space-between',
            alignItems: 'center',
            backgroundColor: Colors.default.main,
          }}
        >
          <View style={{ padding: 10, paddingLeft: 25 }}>
            <Text
              style={{
                fontSize: 42,
                fontWeight: 700,
                color: Colors.default.background,
              }}
            >
              SAVER
            </Text>
          </View>
          <Pressable onPress={() => router.navigate('person')}>
            <View style={{ padding: 10, paddingRight: 25 }}>
              <Ionicons
                name="person-circle-sharp"
                size={32}
                color={Colors.default.background}
              />
            </View>
          </Pressable>
        </View>
      </View>
      <View
        style={{
          alignItems: 'center',
          backgroundColor: Colors.default.background,
          padding: 20,
        }}
      >
        <View>
          <Text style={{ fontWeight: 500, fontSize: 38 }}>R$ {balance}</Text>
        </View>
        <View>
          <Text style={{ fontSize: 18 }}>Your balance</Text>
        </View>
      </View>
      <ScrollView>
        {finances?.length === 0
          ? null
          : finances?.map(finance => (
              <SaverItemCard
                key={finance.id}
                title={finance.description}
                type={finance.type}
                value={finance.amount}
              />
            ))}
      </ScrollView>
      <HomeFooter />
    </View>
  );
};

export default Home;
