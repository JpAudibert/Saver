export const handleNumberToCurrency = (value: number) => {
  return value.toFixed(2).replace('.', ',');
};
