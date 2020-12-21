import { combineEpics } from 'redux-observable';

import loadingEpic from './loading';

// pages epics
import loginEpic from './pages/login';

export default combineEpics(
  loadingEpic,

  // pages epics
  loginEpic,
);
