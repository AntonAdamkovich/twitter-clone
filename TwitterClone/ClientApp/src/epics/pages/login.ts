import { combineEpics, Epic } from 'redux-observable';
import { catchError, map, switchMap, pluck, filter } from 'rxjs/operators';
import { ajax } from 'rxjs/ajax';
import { of } from 'rxjs';
import { isActionOf } from 'typesafe-actions';

import * as Endpoints from '../../constants/endpoints';

import * as LoginActionCreators from '../../actionCreators/pages/login';

import { IRootAction } from '../../actionCreators';

const loginFlow: Epic<IRootAction, IRootAction> = (action$) =>
  action$.pipe(
    filter(isActionOf(LoginActionCreators.submitLoginAsync.request)),
    pluck('payload'),
    switchMap(payload =>
      ajax.post(Endpoints.LOGIN, payload).pipe(
        map(LoginActionCreators.submitLoginAsync.success),
        catchError(error => of(LoginActionCreators.submitLoginAsync.failure(error))),
      )
    )
  );

export default combineEpics(
  loginFlow,
);
