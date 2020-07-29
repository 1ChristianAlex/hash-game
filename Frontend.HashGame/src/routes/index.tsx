import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { ListGames, JoinGame } from '../Pages';

const AppRoutes: React.FC = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/">
          <ListGames />
        </Route>
        <Route exact path="/:id/join">
          <JoinGame />
        </Route>
      </Switch>
    </BrowserRouter>
  );
};

export default AppRoutes;
