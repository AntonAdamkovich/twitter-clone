import { combineEpics, Epic } from 'redux-observable';
import { catchError, map, switchMap } from 'rxjs/operators';
import { ajax } from 'rxjs/ajax';
import { of } from 'rxjs';

import * as Endpoints from '../../constants/endpoints';

import * as LoginActionTypes  from '../../actionTypes/pages/login';
import * as LoginActionCreators from '../../actionCreators/pages/login';

import { RootAction } from '../../actionCreators';

const loginFlow: Epic<RootAction, RootAction> = (action$) =>
  action$.ofType(LoginActionTypes.SUBMIT_LOGIN_REQUEST).pipe(
    switchMap(action =>
      ajax(Endpoints.LOGIN).pipe(
        map(LoginActionCreators.submitLoginAsync.success),
        catchError(error => of(LoginActionCreators.submitLoginAsync.failure(error))),
      )
    )
  );

export default combineEpics(
  loginFlow,
);
