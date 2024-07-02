import React, {
  createContext,
  useCallback,
  useState,
  useContext,
  useEffect,
  useMemo,
} from 'react';
import api from '@/services/api';

interface User {
  id: string;
  name: string;
  email: string;
}

interface AuthState {
  token: string;
  user: User;
}

interface SignInCredentials {
  email: string;
  password: string;
}

interface SignUpCredentials {
  email: string;
  password: string;
  cpf: string;
  name: string;
}

interface AuthContextData {
  user: User;
  loading: boolean;
  signIn(credentials: SignInCredentials): Promise<void>;
  signOut(): void;
  updateUser(user: User): Promise<void>;
  signUp(credentials: SignUpCredentials): Promise<void>;
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

interface AuthProviderProps {
  children: React.ReactNode;
}

const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [data, setData] = useState<AuthState>({} as AuthState);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function loadStoragedData(): Promise<void> {
      // const [token, user] = await AsyncStorage.multiGet([
      //   '@GoBarber:token',
      //   '@GoBarber:user',
      // ]);

      // if (token[1] && user[1]) {
      //   api.defaults.headers.authorization = `Bearer ${token[1]}`;

      //   setData({ token: token[1], user: JSON.parse(user[1]) });
      // }

      setLoading(false);
    }

    loadStoragedData();
  }, []);

  const signIn = useCallback(async ({ email, password }: SignInCredentials) => {
    const response = await api.post('authentication', {
      email,
      password,
    });
    const { token, id, name, responseEmail } = response.data;
    // await AsyncStorage.multiSet([
    //   ['@GoBarber:token', token],
    //   ['@GoBarber:user', JSON.stringify(user)],
    // ]);
    api.defaults.headers.authorization = `Bearer ${token}`;
    api.defaults.headers.userId = `${id}`;
    setData({ token, user: { id, name, email: responseEmail } });
  }, []);

  const signOut = useCallback(async () => {
    // await AsyncStorage.multiRemove(['@GoBarber:token', '@GoBarber:user']);

    setData({} as AuthState);
  }, []);

  const updateUser = useCallback(
    async (user: User) => {
      // await AsyncStorage.setItem('@GoBarber:user', JSON.stringify(user));
      setData({
        token: data.token,
        user,
      });
    },
    [setData, data.token],
  );

  const signUp = useCallback(
    async ({ email, password, cpf, name }: SignUpCredentials) => {
      await api.post('users', {
        name,
        email,
        password,
        identificationNumber: cpf,
        isActive: true,
      });

      await signIn({ email, password });
    },
    [signIn],
  );

  const value = useMemo(
    () => ({
      user: data.user,
      loading,
      signIn,
      signOut,
      updateUser,
      signUp,
    }),
    [data.user, loading, signIn, signOut, signUp, updateUser],
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

function useAuth(): AuthContextData {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error('useAuth must be used within a AuthProvider');
  }

  return context;
}

export { AuthProvider, useAuth };
