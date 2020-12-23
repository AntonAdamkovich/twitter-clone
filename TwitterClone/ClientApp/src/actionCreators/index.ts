import { ActionType } from 'typesafe-actions';
import { LocationChangeAction, CallHistoryMethodAction } from 'connected-react-router';

import * as LoadingActionCreators from './loading';
// import * as RoutingActionCreators from './routing';

// pages
import * as LoginActionCreators from './pages/login';
import * as RegistrationActionCreators from './pages/registration';

type RouterActionTypes = LocationChangeAction | CallHistoryMethodAction;

type ExistingActionTypes = RouterActionTypes
  | typeof LoadingActionCreators
  | typeof LoginActionCreators
  | typeof RegistrationActionCreators;

export type IRootAction = ActionType<ExistingActionTypes>
