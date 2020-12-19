import { createSelector, Selector } from 'reselect';
import { IStore } from '../reducers';
import { ILoadingState } from '../reducers/loading';

export const loading: Selector<IStore, ILoadingState> = (state) => state.loading;

export const isLoading = createSelector<IStore, ILoadingState, boolean>(
  loading,
  loadingState => loadingState.isLoading,
);
