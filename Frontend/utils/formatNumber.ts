export const handleNumberToCurrency = (value: number) => {
  return value
    .toFixed(2)
    .replace('.', ',')
    .replace(/(\d)(?=(\d{3})+,)/g, '$1.');
};
