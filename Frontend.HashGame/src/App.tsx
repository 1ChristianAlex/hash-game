import React from 'react';
import AppRoutes from './routes';
import { Store } from './store';

function App() {
  return (
    <>
      <Store>
        <AppRoutes />
      </Store>
    </>
  );
}

export default App;
