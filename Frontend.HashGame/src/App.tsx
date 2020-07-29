import React from 'react';
import AppRoutes from './Routes';
import { Store } from './Store';
import 'bootstrap/dist/css/bootstrap.min.css';
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
