import { applyMiddleware, createStore } from 'redux';
import { persistStore } from 'redux-persist';
import { routerMiddleware } from 'connected-react-router';
import { createEpicMiddleware } from 'redux-observable';
import logger from 'redux-logger';

import rootReducer from '../reducers';
import rootEpic from '../epics';
import history from './history';

const epicMiddleware = createEpicMiddleware();
const middleware = [routerMiddleware(history), epicMiddleware];

if (process.env.NODE_ENV === 'development') {
  middleware.push(logger);
}

export const store = createStore(
  rootReducer,
  applyMiddleware(...middleware)
);

epicMiddleware.run(rootEpic);

export const persistor = persistStore(store);
