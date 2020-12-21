import { ActionType } from 'typesafe-actions';

import * as LoadingActionCreators from './loading';
import * as RoutingActionCreators from './routing';

// pages
import * as LoginActionCreators from './pages/login';
import * as RegistrationActionCreators from './pages/registration';

type ExistingActionTypes = typeof LoadingActionCreators
  | typeof RoutingActionCreators
  | typeof LoginActionCreators
  | typeof RegistrationActionCreators;

export type RootAction = ActionType<ExistingActionTypes>
