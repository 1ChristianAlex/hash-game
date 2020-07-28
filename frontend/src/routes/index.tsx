import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { ListGames } from '../Pages';

const AppRoutes: React.FC = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/">
          <ListGames />
        </Route>
      </Switch>
    </BrowserRouter>
  );
};

export default AppRoutes;
