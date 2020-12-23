import { combineEpics, Epic } from 'redux-observable';
import { take, mergeMap } from 'rxjs/operators';
// import { of } from 'rxjs';

import { LOCATION_CHANGE } from 'connected-react-router';

// import * as UserActionCreators from '../actionCreators/user';
// import * as LoadingActionCreators from '../actionCreators/loading';

import { IRootAction } from '../actionCreators';
import { IStore } from '../reducers';

const initialize: Epic<IRootAction, IRootAction, IStore> = (action$, state$) =>
  action$
    .ofType(LOCATION_CHANGE)
    .pipe(
      take(1),
      // mergeMap(() => of())
    );

export default combineEpics(
  initialize
);
