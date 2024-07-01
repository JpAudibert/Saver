/**
 * Below are the colors that are used in the app. The colors are defined in the light and dark mode.
 * There are many other ways to style your app. For example, [Nativewind](https://www.nativewind.dev/), [Tamagui](https://tamagui.dev/), [unistyles](https://reactnativeunistyles.vercel.app), etc.
 */

const tintColorLight = '#0a7ea4';
const mainColor = '#238544';
const secondaryColor = '#85BB7D';
const backgroundColor = '#F6FCF6';
const textColor = '#161925';
const spendingColor = '#B12428';
const accentColor = '#235789';

export const Colors = {
  light: {
    text: textColor,
    background: backgroundColor,
    tint: tintColorLight,
    icon: '#687076',
    tabIconDefault: '#687076',
    tabIconSelected: tintColorLight,
  },
  default: {
    main: mainColor,
    secondary: secondaryColor,
    text: textColor,
    background: backgroundColor,
    spending: spendingColor,
    accent: accentColor,
    gray: '#687076',
  },
};
