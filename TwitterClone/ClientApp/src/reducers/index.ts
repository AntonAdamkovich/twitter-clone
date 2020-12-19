import { combineReducers } from 'redux';
import { connectRouter, RouterRootState } from 'connected-react-router'
import { persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';

import browserHistory from '../store/history';
import { loading, ILoadingState } from './loading';

const rootPersistConfig = {
  key: 'root',
  storage,
  blacklist: ['loading'],
};

const rootReducer = combineReducers({
  router: connectRouter(browserHistory),
  loading,
});

export interface IStore {
  loading: ILoadingState;
  router: RouterRootState;
}

export default persistReducer(rootPersistConfig, rootReducer);
