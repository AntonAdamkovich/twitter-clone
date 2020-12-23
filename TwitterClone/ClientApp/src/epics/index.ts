import { combineEpics } from 'redux-observable';

import loadingEpic from './loading';
import initializeEpic from './initialize';

// pages epics
import loginEpic from './pages/login';
import registrationEpic from './pages/registration';

export default combineEpics(
  loadingEpic,
  initializeEpic,

  // pages epics
  loginEpic,
  registrationEpic,
);
