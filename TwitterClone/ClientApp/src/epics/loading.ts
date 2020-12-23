import { combineEpics, Epic } from 'redux-observable';
import { map } from 'rxjs/operators';

import * as LoginActionTypes from '../actionTypes/pages/login';
import * as RegistrationActionTypes from '../actionTypes/pages/registration';
import * as LoadingActionCreators from '../actionCreators/loading';

import { IRootAction } from '../actionCreators';

const startLoadingEpic: Epic<IRootAction, IRootAction> = (action$) =>
  action$.ofType(
    LoginActionTypes.SUBMIT_LOGIN_REQUEST,
    RegistrationActionTypes.SUBMIT_REGISTRATION_REQUEST,
  ).pipe(
    map(LoadingActionCreators.startLoading),
  );

const FinishLoadingEpic: Epic<IRootAction, IRootAction> = (action$) =>
  action$.ofType(
    LoginActionTypes.SUBMIT_LOGIN_FAILURE,
    LoginActionTypes.SUBMIT_LOGIN_SUCCESS,
    RegistrationActionTypes.SUBMIT_REGISTRATION_FAILURE,
    RegistrationActionTypes.SUBMIT_REGISTRATION_SUCCESS,
  ).pipe(
    map(LoadingActionCreators.finishLoading),
  );

export default combineEpics(
  startLoadingEpic,
  FinishLoadingEpic,
);
