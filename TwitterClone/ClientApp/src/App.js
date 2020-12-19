import React, { Component } from 'react';
import { Route, Switch } from 'react-router-dom';

import { Provider } from 'react-redux';
import { PersistGate } from 'redux-persist/integration/react';
import { ConnectedRouter } from 'connected-react-router';
import { MuiThemeProvider, CssBaseline } from '@material-ui/core';
import { ThemeProvider } from 'styled-components';

import { store, persistor } from './store';
import history from './store/history';
import theme, { GlobalStyle } from './theme';

import * as Routes from './constants/routes';

import Home from './pages/Home';
import Profile from './pages/Profile';
import Login from './pages/Login';
import Registration from './pages/Registration';
import NotFound from './pages/NotFound';

import Loading from './components/Loading';
// import ModalsPortal from './components/ModalsPortal';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Provider store={store}>
        <PersistGate persistor={persistor}>
          <ThemeProvider theme={theme}>
            <MuiThemeProvider theme={theme}>
              <ConnectedRouter history={history}>
                <Loading renderChildren={false}>
                  <GlobalStyle/>
                  <CssBaseline/>
                  <Switch>
                    <Route exact path={Routes.REGISTRATION} component={Registration} />
                    <Route exact path={Routes.PROFILE} component={Profile} />
                    <Route exact path={Routes.LOGIN} component={Login} />
                    <Route exact path={Routes.HOME} component={Home} />
                    <Route path={Routes.UNKNOWN} component={NotFound} />
                  </Switch>
                </Loading>
              </ConnectedRouter>
            </MuiThemeProvider>
          </ThemeProvider>
        </PersistGate>
      </Provider>
    );
  }
}
