import { combineEpics, Epic } from 'redux-observable';
import { catchError, map, switchMap, pluck, filter } from 'rxjs/operators';
import { ajax } from 'rxjs/ajax';
import { of } from 'rxjs';
import { isActionOf } from 'typesafe-actions';

import * as Endpoints from '../../constants/endpoints';

import * as RegistrationActionCreators from '../../actionCreators/pages/registration';

import { IRootAction } from '../../actionCreators';

const registrationFlow: Epic<IRootAction, IRootAction> = (action$) =>
  action$.pipe(
    filter(isActionOf(RegistrationActionCreators.submitRegistrationAsync.request)),
    pluck('payload'),
    switchMap(payload =>
      ajax.post(Endpoints.REGISTRATION, payload).pipe(
        map(RegistrationActionCreators.submitRegistrationAsync.success),
        catchError(error => of(RegistrationActionCreators.submitRegistrationAsync.failure(error))),
      )
    )
  );

export default combineEpics(
  registrationFlow,
);
